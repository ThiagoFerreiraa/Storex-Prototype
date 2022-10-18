import React from 'react'
import './UserDashboard.css'
import Sidebar from '../../components/Sidebar/Sidebar'
import DashboardUsers from '../../components/DashboardUsers/DashboardUsers'
import { Link } from 'react-router-dom'
import { useEffect } from 'react'
import axios from 'axios'
import { useState } from 'react'

const UserDashboard = () => {
    const [data, setData] = useState([]) 

    const URL_API_USER = process.env.REACT_APP_URL_API_USER;

    const getUsers = async () =>{
        axios.get(URL_API_USER).then(response =>{
            setData(response.data)
        }).catch(error => {
            console.log(error)
        })
    }


    useEffect(() => {
        getUsers();    
    },[])

    return (
        <div className='session_register'>
            <Sidebar />
            <div className='Dashboard_session'>
                <div className='header_page'>
                    <h1>Users</h1>
                    <Link id="insert_user" className='btn btn-primary' to="../user/registrationUser" >Insert User</Link>
                </div>
                <DashboardUsers type={"User"} baseData ={data} />
            </div>
        </div>
    )
}


export default UserDashboard