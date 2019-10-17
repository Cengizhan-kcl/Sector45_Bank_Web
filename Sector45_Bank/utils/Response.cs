#region Bütünleştirilmiş Kod SpiceApp.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// D:\ProjectBox\mvs\soapProje\SpiceApp-master\SpiceApp.BusinessLayer\bin\Debug\SpiceApp.Models.dll
#endregion

using System.Collections.Generic;

namespace Sector45_Bank
{
    public class Response<T> where T : class
    {
        public Response() { }
        public string error { get; set; }
        public T data { get; set; }
    }
}