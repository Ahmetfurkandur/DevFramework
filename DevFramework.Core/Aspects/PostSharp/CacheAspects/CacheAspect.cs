using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.PostSharp.CacheAspects
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;

        public CacheAspect(Type cacheType, int cacheTypeByMinute=60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheTypeByMinute;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            //Gönderilen nesne cache manager türünde değilse hata fırlatır
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                throw new Exception("Wrong Cache Manager");

            }

            //Cache manager nesnesinin instance ını oluşturduk
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            //metotun bilgilerini alan değişkenimiz
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name);
            //metotun parametreleri
            var arguments = args.Arguments.ToList();

            //caching esnasında kullanılacak anahtarımız
            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));

            //burada defansif kodlama gerçekleştiriyoruz. Eğer eklenmişse aspectimiz metotu bitiriyor
            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);
            //Eğer eklenmemişse veriyi cacheliyoruz
            _cacheManager.Add(key,args.ReturnValue,_cacheByMinute);
        }
    }
}
