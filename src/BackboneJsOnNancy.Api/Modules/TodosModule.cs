namespace BackboneJsOnNancy.Api.Modules
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