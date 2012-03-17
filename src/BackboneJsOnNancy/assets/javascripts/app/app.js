var App = {
    Models: {},
    Collections: {},
    Views: {},
    Routers: {},
    Data: {},

    initialize: function () {

        this.Data.TodoList = new App.Collections.Todos;

        // ReSharper disable WrongExpressionStatement
        new App.Routers.Todo();
        // ReSharper restore WrongExpressionStatement

        if (!Backbone.history.started) {
            Backbone.history.start();
            Backbone.history.started = true;
        }
    },

    leaveCurrentView: function (newView) {
        if (this.currentView)
            this.currrentView.leave();
        this.currentView = newView;
    }

};