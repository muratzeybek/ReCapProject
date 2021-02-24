using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Birkaç farklı default false yapalım. Aslında DataResult la yapabiliriz. 
    // ma alt yapımızı framework umuzu iyileştiriyoruz. 
    public class ErrorDataResult<T> : DataResult<T>
    {
        // Bana bir data bir de mesaj ver.
        // Ama base a (dataresult)a bu işlemin sonucu datadır. Sonucu false dur. Mesaj şudur de.
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        // hiç mesaj olayına girmek istemiyorsa.
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        // Çok az kullanacağımız bir versiyon. Sadece mesaj için...
        // 
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        // Hiçbirşey vermek istemiyorum. Base e default datam budur. Mesaj vermiyorum. 
        public ErrorDataResult() : base(default, false)
        {

        }

    }

}
