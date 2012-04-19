﻿var App = App || {};
App.Public = {

    Models: {},
    Collections: {},
    Views: {},
    Routers: {},

    initialize: function (options) {
        options || (options = {});
        if (options.path) {
            if (options.path === '/register') {
                // ReSharper disable WrongExpressionStatement
                new App.Public.Views.RegisterView();
                // ReSharper restore WrongExpressionStatement
            }
        }
    }

};