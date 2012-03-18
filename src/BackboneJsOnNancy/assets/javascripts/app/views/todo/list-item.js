App.Views.TodoListItem = Support.CompositeView.extend({

    tagName: 'li',
    templateName: 'todo-list-item',

    events: {
        'click span.todo-destroy': 'clear',
        'click :checkbox': 'toggleStatus',
        'dblclick div.todo-text': 'toggleEdit',
        'keypress .todo-input': 'updateModelOnEnter',
        'keyup .todo-input': 'cancelModelUpdateOnEscape'
    },

    initialize: function () {
        _.bindAll(this, 'render', 'clear', 'toggleStatus', 'toggleEdit', 'updateModel', 'updateModelOnEnter', 'cancelModelUpdateOnEscape', 'setStatus');

        this.model.bind('change:content', this.render);
        this.model.bind('change:status', this.setStatus);
    },

    render: function () {
        this.renderTemplate();
        return this;
    },

    renderTemplate: function () {
        var html = this.buildTemplate(this.model.toJSON());
        $(this.el).html(html);
        this.setStatus();
    },

    clear: function () {
        this.collection.remove(this.model);
    },

    toggleStatus: function () {
        this.model.toggleStatus();
    },

    toggleEdit: function () {
        $(this.el).toggleClass('editing');
        this.$('input').focus();
    },

    updateModel: function () {
        this.toggleEdit();
        this.model.set({
            content: this.$('.todo-input').val()
        });
    },

    updateModelOnEnter: function (e) {
        if (e.keyCode == 13) {
            this.updateModel();
        }
    },

    cancelModelUpdateOnEscape: function (e) {
        if (e.keyCode == 27) {
            this.toggleEdit();
        }
    },

    setStatus: function () {
        if (this.model.isComplete()) {
            this.$('.todo').addClass('done');
        }
        else {
            this.$('.todo').removeClass('done');
        }
    }

});