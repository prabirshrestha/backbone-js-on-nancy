App.Views.TodoIndex = Support.CompositeView.extend({

    templateName: 'todo-index',

    initialize: function () {
        this.views = {};
    },

    render: function () {
        this.renderTemplate();
        this.renderFormTemplate();
        this.renderListTemplate();
        return this;
    },

    renderTemplate: function () {
        var html = this.buildTemplate();
        $(this.el).html(html);
    },

    renderFormTemplate: function () {
        var formView = this.views.formView = new App.Views.TodoForm();
        this.renderChild(formView);
        this.$('.content').append(formView.el);
    },

    renderListTemplate: function () {
        var listView = this.views.listView = new App.Views.TodoList({
            collection: this.collection
        });

        this.renderChild(listView);
        this.$('.content').append(listView.el);
    }

});