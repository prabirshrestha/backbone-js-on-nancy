var App = App || {};
App.Public = {

    Models: {},
    Collections: {},
    Views: {},
    Routers: {},

    initialize: function (options) {
        options || (options = {});

        // ReSharper disable WrongExpressionStatement
        if (options.path) {
            if (options.path === '/register') {
                new App.Public.Views.RegisterView();
            } else if (options.path === '/login') {
                new App.Public.Views.LoginView();
            }
        }
        new App.Public.Views.HeaderView();
        // ReSharper restore WrongExpressionStatement        
    }

};