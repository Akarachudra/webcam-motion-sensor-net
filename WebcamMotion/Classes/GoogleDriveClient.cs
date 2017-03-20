using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using WebcamMotion.Helpers;
using WebcamMotion.Resources;
using File = Google.Apis.Drive.v2.Data.File;

namespace WebcamMotion.Classes
{
    public class GoogleDriveClient : IGoogleDriveClient
    {
        private readonly IStringResources stringResources;
        private readonly ISettingsController settingsController;
        private readonly IFormLogger logger;
        private const string ClientId = "226554284789-hcp98n2gt638vicnfv7o345313lde0pl.apps.googleusercontent.com";
        private const string ClientSecret = "zVePjv-YNDkXZFmzUcxWP-W0";
        private string folderId;
        private static readonly string[] Scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private DriveService service;
        private bool isInited;

        public GoogleDriveClient(IStringResources stringResources, ISettingsController settingsController, IFormLogger logger)
        {
            this.stringResources = stringResources;
            this.settingsController = settingsController;
            this.logger = logger;
        }

        public async void Init()
        {
            if (isInited) return;
            try
            {
                var googleClientSecrets = new ClientSecrets();
                googleClientSecrets.ClientId = ClientId;
                googleClientSecrets.ClientSecret = ClientSecret;
                UserCredential credential;
                if (!string.IsNullOrEmpty(settingsController.GoogleApiRefreshToken))
                {
                    try
                    {
                        var token = new TokenResponse { RefreshToken = settingsController.GoogleApiRefreshToken };
                        credential = new UserCredential(new GoogleAuthorizationCodeFlow(
                            new GoogleAuthorizationCodeFlow.Initializer
                            {
                                ClientSecrets = googleClientSecrets
                            }), "user", token);
                    }
                    catch
                    {
                        credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                            googleClientSecrets, Scopes, "user", CancellationToken.None);
                        settingsController.GoogleApiRefreshToken = credential.GetAccessTokenForRequestAsync().Result;
                    }
                }
                else
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        googleClientSecrets, Scopes, "user", CancellationToken.None);
                    settingsController.GoogleApiRefreshToken = credential.Token.RefreshToken;
                }

                service = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Webcam Motion Sensor"
                });

                FolderDateNameUpdater();
                isInited = true;
            }
            catch (Exception e)
            {
                logger.Log($"{stringResources.Error} {e.Message}");
            }
        }

        public async Task<bool> UploadJpeg(string path)
        {
            if (!isInited) return false;
            var fileName = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(folderId))
                    folderId = CreateCurrentDateFolder();
                var parentReference = new ParentReference { Id = folderId };
                using (var uploadStream =
                    new FileStream(
                        path,
                        FileMode.Open,
                        FileAccess.Read, FileShare.Delete))
                {
                    fileName = Path.GetFileName(path);
                    var insert =
                        service.Files.Insert(
                            new File { Title = fileName, Parents = new List<ParentReference> { parentReference } },
                            uploadStream, "image/jpeg");
                    insert.ChunkSize = ResumableUpload.MinimumChunkSize * 2;

                    var result = await insert.UploadAsync();
                    if (result.Exception != null)
                    {
                        throw result.Exception;
                    }
                    return result.Status == UploadStatus.Completed;
                }
            }
            catch (Exception e)
            {
                logger.Log($"{stringResources.FileUploadException}: {fileName} {e.Message}");
                return false;
            }
        }

        private string CreateCurrentDateFolder()
        {
            var fileMetadata = new File
            {
                MimeType = "application/vnd.google-apps.folder",
                Title = $"{DateTime.Now.ToShortDateString()} Webcam Motion Sensor"
            };
            var request = service.Files.Insert(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();
            return file.Id;
        }

        private async void FolderDateNameUpdater()
        {
            while (true)
            {
                if (Math.Abs(DateTime.Now.Day - DateTime.Now.AddMinutes(-1).Day) >= 1 && !string.IsNullOrEmpty(folderId))
                {
                    folderId = CreateCurrentDateFolder();
                    await Task.Delay(60000);
                }
                await Task.Delay(20000);
            }
        }
    }
}