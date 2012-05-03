App.Public.Views.LoginView = Support.CompositeView.extend({

    el: $('div[role="main"] form[role=login]'),

    events: {
        'submit form': 'onFormSubmit'
    },

    initialize: function () {
        _.bindAll(this, 'onFormSubmit');
        console.log(this.el)
    },

    onFormSubmit: function (e) {
        this.$('input[type=submit]')
            .attr('readonly', 'readonly')
            .addClass('disabled');
        this.$('input[type=password]').val('');
    }

});