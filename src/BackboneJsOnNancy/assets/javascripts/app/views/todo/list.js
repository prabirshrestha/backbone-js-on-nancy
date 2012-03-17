App.Views.TodoList = Support.CompositeView.extend({

    tagName: 'ul',
    id: 'todo-list',

    initialize: function () {
    },

    render: function () {
        this.renderListItems();
        return this;
    },

    renderListItems: function () {
        var self = this;

        this.collection.each(function (model) {
            var row = new App.Views.TodoListItem({
                model: model
            });

            self.renderChild(row);
            $(self.el).append(row.el);
        });
    }

});