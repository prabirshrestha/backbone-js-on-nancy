App.Routers.About = Support.SwappingRouter.extend({

    initialize: function () {
        this.el = $('#app');
    },

    routes: {
        'about': 'index'
    },

    index: function () {
        var router = this;
        var view = new App.Views.AboutIndex();

        App.leaveCurrentView(view);
        router.swap(view);
    }

});