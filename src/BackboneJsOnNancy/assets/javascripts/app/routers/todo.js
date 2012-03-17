App.Routers.Todo = Support.SwappingRouter.extend({

    initialize: function () {
        this.el = $('#app');
    },

    routes: {
        "": "index"
    },

    index: function () {
        var view = new App.Views.TodoIndex();

        App.leaveCurrentView(view);
        this.swap(view);
    }

});