App.Models.Todo = Backbone.Model.extend({
    defaults: function () {
        return {
            done: false,
            order: App.TodoList.nextOrder()
        };
    },

    toggle: function () {
        this.save({ done: !this.get('done') });
    }
});