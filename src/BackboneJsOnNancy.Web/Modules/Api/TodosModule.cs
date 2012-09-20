namespace BackboneJsOnNancy.Web.Modules.Api
{
    public class TodosModule : ApiModule
    {
        public TodosModule()
            : base("/todos")
        {
            Get["/"] = x => "todos";
        }
    }
}