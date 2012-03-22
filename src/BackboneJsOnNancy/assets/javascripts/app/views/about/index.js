App.Views.AboutIndex = Support.CompositeView.extend({

    templateName: 'about-index',

    initialize: function () {
        this.views = {};
    },

    render: function () {
        this.renderTemplate();
        return this;
    },

    renderTemplate: function () {
        $(this.el).empty();
        console.log('about-index');
    }

});