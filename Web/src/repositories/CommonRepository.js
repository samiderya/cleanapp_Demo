import Repository from './Repository';

export default {
    get(resource) {
        console.log('Get Repository==', resource);
        return Repository.get(resource);
    },
    post(resource, payLoad) {
        console.log(
            'resource==',
            resource + ' payLoad==' + Object.values(payLoad)
        );
        return Repository.post(resource, payLoad);
    }
};
