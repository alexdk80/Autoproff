import axios from 'axios'

const client = axios.create({
    baseURL: 'http://localhost:5000/api',
    json: true
})

export default{
    async execute(method, resource, data){
        return client({
            method,
            url:resource,
            data            
        }).then(req =>{
            return req.data
        })
    },    
    getAll(){
        return this.execute('get','/GetAll')
    },
    create(data){
        return this.execute('post', '/Create/', data)
    },
    update(id, data){
        return this.execute('put', `/Update/${id}`, data)
    },
    delete(id){
        return this.execute('delete', `/Delete/${id}`)
    }
}