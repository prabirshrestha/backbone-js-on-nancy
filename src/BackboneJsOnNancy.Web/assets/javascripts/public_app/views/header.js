App.Public.Views.HeaderView = Support.CompositeView.extend({

    el: $('#header'),

    initialize: function () {
        _.bindAll(this, 'render');
        this.render();
    },

    render: function () {
        this.$('a.dropdown-toggle').attr('href', '#');
    }

});