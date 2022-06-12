const endpoints = {
    remarks: {
        getAll: '/remarks',
        create: '/remarks',
        edit: '/remarks/{{id}}',
        delete: '/remarks/{{id}}',
        getById: '/remarks/{{id}}',
    },
    shouts: {
        getAll: '/shouts',
        create: '/shouts',
        edit: '/shouts/{{id}}',
        delete: '/shouts/{{id}}',
        getById: '/shouts/{{id}}',
    }
};

export default endpoints;