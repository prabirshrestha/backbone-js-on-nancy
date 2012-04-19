App.Public.Views.RegisterView = Support.CompositeView.extend({

    el: $('div[role="main"] form[role=register]'),

    events: {
        'click input[role=cancel]': 'cancel'
    },

    initialize: function () {
        _.bindAll(this, 'cancel');
        this.inputs = this.$('input[type=email], input[type=password]');
    },

    cancel: function (e) {
        e.preventDefault();
        this.inputs.val('');
    }

});