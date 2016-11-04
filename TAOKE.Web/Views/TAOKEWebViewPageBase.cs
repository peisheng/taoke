using Abp.Web.Mvc.Views;

namespace TAOKE.Web.Views
{
    public abstract class TAOKEWebViewPageBase : TAOKEWebViewPageBase<dynamic>
    {

    }

    public abstract class TAOKEWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TAOKEWebViewPageBase()
        {
            LocalizationSourceName = TAOKEConsts.LocalizationSourceName;
        }
    }
}