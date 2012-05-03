var App = App || {};
App.Public = {

    Models: {},
    Collections: {},
    Views: {},
    Routers: {},

    initialize: function (options) {
        options || (options = {});
        $('.dropdown-toggle').dropdown();

        if (options.path) {
            // ReSharper disable WrongExpressionStatement
            if (options.path === '/register') {
                new App.Public.Views.RegisterView();
            } else if (options.path === '/login') {
                new App.Public.Views.LoginView();
            }
            // ReSharper restore WrongExpressionStatement
        }
    }

};