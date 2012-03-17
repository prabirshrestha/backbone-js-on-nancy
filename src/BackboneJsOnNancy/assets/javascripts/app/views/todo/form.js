App.Views.TodoForm = Support.CompositeView.extend({

    templateName: 'todo-form',

    events: {
        'submit #todo-form': 'save'
    },

    render: function () {
        var html = this.buildTemplate();
        $(this.el).html(html);
        return this;
    },

    save: function () {
        var val = this.$('input').val();
        var model = new App.Models.Todo({
            name: val,
            id: App.Data.Todos.length
        });
        model.save();

        this.$('input').val();
        event.preventDefault();
    }

});