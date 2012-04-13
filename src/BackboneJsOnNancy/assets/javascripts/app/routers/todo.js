App.Routers.Todo = Support.SwappingRouter.extend({

    initialize: function (options) {
        this.el = $('#app');
        this.todos = options.todos;
    },

    routes: {
        "": "index"
    },

    index: function () {
        var router = this;
        var view = new App.Views.TodoIndex({
            collection: this.todos,
            router: router
        });

        this.swap(view);
    }

});