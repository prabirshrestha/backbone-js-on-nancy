App.Public.Views.LoginView = Support.CompositeView.extend({

    el: $('div[role="main"] form[role=login]'),

    events: {
        'submit': 'onFormSubmit'
    },

    initialize: function () {
        _.bindAll(this, 'onFormSubmit');
    },

    onFormSubmit: function (e) {
        this.$('input[type=submit]')
            .attr('readonly', 'readonly')
            .addClass('disabled');

        var self = this;
        setTimeout(function () {
            self.$('input[type=password]').val('');
        }, 200);
    }

});