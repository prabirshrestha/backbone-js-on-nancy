App.Public.Views.RegisterView = Support.CompositeView.extend({

    el: $('.container form[role=register]'),

    events: {
        'click input[role=cancel]': 'cancel'
    },

    initialize: function () {
        _.bindAll(this, 'cancel');
        this.inputs = this.$('input[type=text], input[type=password]');
    },

    cancel: function (e) {
        e.preventDefault();
        this.inputs.val('');
    }

});