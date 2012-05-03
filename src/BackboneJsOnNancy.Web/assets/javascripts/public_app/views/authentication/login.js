App.Public.Views.LoginView = Support.CompositeView.extend({

    el: $('div[role="main"] form[role="login"]'),

    events: {
        'click input[type=submit]': 'login'
    },

    initialize: function () {
        _.bindAll(this, 'login');
    },

    login: function (e) {
        this.$('input[type=submit]')
            .attr('readonly', 'readonly')
            .addClass('disabled');
    }

});