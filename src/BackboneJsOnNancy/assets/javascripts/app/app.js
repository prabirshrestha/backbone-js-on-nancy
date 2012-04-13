var App = {
    Models: {},
    Collections: {},
    Views: {},
    Routers: {},
    Data: {},

    initialize: function (options) {
        options || (options = {});

        this.todos = new App.Collections.Todos(options.todos);

        // ReSharper disable WrongExpressionStatement
        new App.Routers.Todo({ todos: this.todos });
        new App.Routers.About();
        // ReSharper restore WrongExpressionStatement

        if (!Backbone.history.started) {
            Backbone.history.start();
            Backbone.history.started = true;
        }
    },

    leaveCurrentView: function (newView) {
        if (this.currentView)
            this.currentView.leave();
        this.currentView = newView;
    }

};