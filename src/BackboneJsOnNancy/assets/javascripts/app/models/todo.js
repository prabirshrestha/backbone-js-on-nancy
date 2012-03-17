App.Models.Todo = Backbone.Model.extend({

    defaults: {
        status: 'complete'
    },

    isComplete: function () {
        return this.get('status') === 'completed';
    },

    toggleStatus: function () {
        this.get('status') === 'incomplete' ? this.set({ status: 'completed' }) : this.set({ status: 'incomplete' });
    }
});