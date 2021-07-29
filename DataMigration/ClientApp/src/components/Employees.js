import React, { Component } from 'react';

export class Employees extends Component {
    static displayName = Employees.name;

    constructor(props) {
        super(props);
        this.state = { employees: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(employees) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name (C)</th>
                        <th>Salary</th>
                        <th>Designation</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.map(emp =>
                        <tr key={emp.employeeId}>
                            <td>{emp.firstName}</td>
                            <td>{emp.lastName}</td>
                            <td>{emp.salary}</td>
                            <td>{emp.designation}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    onClick = async () => {
        await fetch('employees', { method: 'POST' })
        this.populateWeatherData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Employees.renderForecastsTable(this.state.employees);

        return (
            <div>
                <div>
                    <button className="btn btn-primary" onClick={this.onClick}>Migrate Data</button>
                </div>
                <div>
                    <h1 id="tabelLabel" >Employees</h1>
                    {contents}
                </div>

            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('employees');
        const data = await response.json();
        this.setState({ employees: data, loading: false });
    }
}
