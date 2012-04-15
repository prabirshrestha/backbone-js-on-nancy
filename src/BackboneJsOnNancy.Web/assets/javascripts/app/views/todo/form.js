App.Views.TodoForm = Support.CompositeView.extend({

    templateName: 'todo-form',

    events: {
        'submit #todo-form': 'save'
    },

    initialize: function () {
        _.bindAll(this, 'render');
    },

    render: function () {
        var html = this.buildTemplate();
        this.$el.html(html);
        return this;
    },

    save: function (e) {
        e.preventDefault();
        
        var input = this.$('input');

        var model = new App.Models.Todo({
            content: input.val(),
            id: App.todos.length
        });

        model.save();
        input.val('');
    }

});