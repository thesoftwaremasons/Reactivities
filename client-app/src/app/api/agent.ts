import  axios, { AxiosResponse }  from "axios";
import { resolve } from "dns";
import { IActivity } from "../modules/activity";
axios.defaults.baseURL="http://localhost:5000/api"
const responseBody=(response:AxiosResponse)=>response.data

const sleep=(ms:number)=>(response:AxiosResponse)=>
    new Promise<AxiosResponse>(resolve=>setTimeout(()=>resolve(response),ms))

const requests={
    get:(url:string)=>axios.get(url).then(sleep(1000)).then(responseBody),
    post:(url:string,body:{})=>axios.post(url,body).then(responseBody),
    put:(url:string,body:{})=>axios.put(url,body).then(responseBody),
    del:(url:string)=>axios.delete(url).then(sleep(1000)).then(responseBody)

}

const Activities={
    list:():Promise<IActivity[]>=>requests.get('/Activities'),
    details:(id:string)=>requests.get(`/Activities/${id}`),
    create:(activity:IActivity)=>requests.post('/Activities/',activity),
    update:(activity:IActivity)=>requests.put(`/Activities/${activity.id}`,activity),
    delete:(id:string)=>requests.del(`/Activities/${id}`)

}
export default{
    Activities
}