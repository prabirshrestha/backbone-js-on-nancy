App.Views.TodoList = Support.CompositeView.extend({

    tagName: 'ul',
    id: 'todo-list',

    initialize: function () {
        _.bindAll(this, 'render');
        this.collection.bind('add', this.render);
        this.collection.bind('remove', this.render);
    },

    render: function () {
        this.renderListItems();
        return this;
    },

    renderListItems: function () {
        var self = this;
        $(this.el).empty();

        this.collection.each(function (model) {
            var row = new App.Views.TodoListItem({
                model: model,
                collection: self.collection
            });

            self.renderChild(row);
            $(self.el).append(row.el);
        });
    }

});