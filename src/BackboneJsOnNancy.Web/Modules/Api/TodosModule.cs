namespace BackboneJsOnNancy.Modules.Api
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