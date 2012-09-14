App.Public.Views.LoginView = Support.CompositeView.extend({

    el: $('div[role="main"] form[role=login]'),

    events: {
        'submit': 'onFormSubmit'
    },

    initialize: function () {
        _.bindAll(this, 'onFormSubmit');
    },

    onFormSubmit: function (e) {
        var self = this;
        setTimeout(function () {
            self.$('input[type=submit]')
                .attr('disabled', 'disabled')
                .addClass('disabled');
            self.$('input[type=password]').val('');
        }, 200);
    }

});