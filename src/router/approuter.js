// imports from vue
import Vue from 'vue'
import Router from 'vue-router'



// imports
import CarAuction from '@/components/CarAuction'
import CarRecords from '@/components/CarRecords'

Vue.use(Router)

let router = new Router({
  mode: 'history',
  routes: [
	{
  	path: '/',
  	name: 'CarAuction',
  	component: CarAuction
	},
	{
	path: '/car-records',
	name: 'GetAll',
	component: CarRecords	
	}
  ]
})

export default router