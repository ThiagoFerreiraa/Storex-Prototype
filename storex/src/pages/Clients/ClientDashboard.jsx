import React from 'react'
import Sidebar from '../../components/Sidebar/Sidebar'
import DashboardUsers from '../../components/DashboardUsers/DashboardUsers'
import { Link } from 'react-router-dom'

const ClientDashboard = () => {
    return (
        <div className='session_register'>
            <Sidebar />
            <div className='Dashboard_session'>
                <div className='header_page'>
                    <h1>Clients</h1>
                    <Link id="insert_user" className='btn btn-primary' to="../client/registrationClient" >Insert Client</Link>
                </div>
                <DashboardUsers type={"Client"} />
            </div>
        </div>
    )
}

export default ClientDashboard