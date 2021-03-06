﻿var App = App || { };

App = {

    Models: {},
    Collections: {},
    Views: {},
    Routers: {},

    initialize: function (options) {
        options || (options = {});

        this.todos = new App.Collections.Todos(options.todos);

        // ReSharper disable WrongExpressionStatement
        new App.Routers.Todo({ todos: this.todos });
        new App.Routers.About();
        new App.Views.HeaderView();
        // ReSharper restore WrongExpressionStatement

        if (!Backbone.history.started) {
            Backbone.history.start();
            Backbone.history.started = true;
        }
    }

};