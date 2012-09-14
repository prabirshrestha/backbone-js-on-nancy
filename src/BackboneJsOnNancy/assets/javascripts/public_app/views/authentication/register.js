App.Public.Views.RegisterView = Support.CompositeView.extend({

    el: $('div[role="main"] form[role=register]'),

    events: {
        'submit': 'onFormSubmit',        
        'click input[role=cancel]': 'cancel'
    },

    initialize: function () {
        _.bindAll(this, 'onFormSubmit', 'cancel');
        this.inputs = this.$('input[type=email], input[type=password]');
    },

    cancel: function (e) {
        e.preventDefault();
        this.inputs.val('');
    },

    onFormSubmit: function (e) {
        var self = this;
        setTimeout(function () {
            self.$('input[type=submit], input[type=button]')
                .attr('disabled', 'disabled')
                .addClass('disabled');
            self.$('input[type=password]').val('');
        }, 200);
    }

});