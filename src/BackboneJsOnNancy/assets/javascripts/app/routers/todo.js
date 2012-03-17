App.Routers.Todo = Support.SwappingRouter.extend({

    initialize: function () {
        this.el = $('#app');
        this.todos = App.Data.Todos;
    },

    routes: {
        "": "index"
    },

    index: function () {
        var router = this;
        var view = new App.Views.TodoIndex({
            collection: this.todos
        });

        App.leaveCurrentView(view);
        router.swap(view);
    }

});