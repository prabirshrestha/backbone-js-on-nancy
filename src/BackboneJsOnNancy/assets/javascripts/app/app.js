var App = {
    Models: {},
    Collections: {},
    Views: {},
    Routers: {},

    initialize: function () {
        console.log('app initialized');
    },

    leaveCurrentView: function (newView) {
        if (this.currentView)
            this.currrentView.leave();
        this.currentView = newView;
    }
};