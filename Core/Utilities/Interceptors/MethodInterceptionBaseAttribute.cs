using Castle.DynamicProxy;
using IInterceptor = Castle.DynamicProxy.IInterceptor;
//using static Core.Utilities.Interceptors.Class1;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor  //Dynamic ekledi ama bende istemedi.
    {
        public int Priority { get; set; }  //Hangi attribute önce çalışsın

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
