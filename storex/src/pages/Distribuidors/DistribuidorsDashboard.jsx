import React from 'react'
import Sidebar from '../../components/Sidebar/Sidebar'
import DashboardUsers from '../../components/DashboardUsers/DashboardUsers'
import { Link } from 'react-router-dom'
import './DistribuidorsDashboard.css'

const DistribuidorsDashboard = () => {
    return (
        <div className='session_register'>
            <Sidebar />
            <div className='Dashboard_session'>
                <div className='header_page'>
                    <h1>Distribuidors</h1>
                    <Link id="insert_Dist" className='btn btn-primary' to="../client/registrationClient" >Insert Distribuidors</Link>
                </div>
                <DashboardUsers type={"Distribuidors"} />
            </div>
        </div>
    )
}

export default DistribuidorsDashboard