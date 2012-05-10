App.Views.AboutIndex = Support.CompositeView.extend({

    templateName: 'about-index',

    initialize: function () {
        _.bindAll(this, 'render');
    },

    render: function () {
        this.renderTemplate();
        return this;
    },

    renderTemplate: function () {
        var html = this.buildTemplate();
        this.$el.html(html);
    }

});