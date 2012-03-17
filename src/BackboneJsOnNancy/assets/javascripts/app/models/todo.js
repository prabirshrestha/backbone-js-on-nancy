App.Models.Todo = Backbone.Model.extend({
    defaults: function () {
        return {
            done: false
        };
    },

    toggle: function () {
        this.save({ done: !this.get('done') });
    }
});