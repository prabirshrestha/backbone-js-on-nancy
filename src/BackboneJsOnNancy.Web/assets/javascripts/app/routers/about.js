App.Routers.About = Support.SwappingRouter.extend({

    initialize: function () {
        this.el = $('#app');
    },

    routes: {
        'about': 'index'
    },

    index: function () {
        var router = this;
        var view = new App.Views.AboutIndex({
            router: router
        });

        this.swap(view);
    }

});