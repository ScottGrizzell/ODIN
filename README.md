# Project ODIN: Offender Data Integrated Network

**Date:** April 2026  
**Prepared By:** Scott Grizzell, Software Developer Applicant  
**Subject:** Modernization of Offender Data Tracking via API Aggregation

---

## Introduction

The purpose of this application is to demonstrate a scalable architectural framework for aggregating fragmented municipal data into a centralized dashboard. This proposal uses a mock scenario (Project ODIN) to showcase how modern .NET and Blazor technologies can bridge the gap between vendor systems and departmental operational needs.

---

## Problem Statement

In the municipal justice environment, justice-involved individuals have data scattered across multiple disconnected platforms, creating significant operational challenges for staff and administrators.

### Affected Systems

- **Financials:** Oracle EnterpriseOne
- **Case Documents:** Doc400 (Legacy System)
- **Collections:** Third-Party Vendor APIs (DOR/PCS)

### Operational Impact

Staff must perform manual cross-referencing of data across systems, leading to increased processing times and a higher probability of data entry errors, particularly regarding community service hours served and outstanding fee statuses.

---

## Proposed Solution

Project ODIN (Offender Data Integrated Network) is a unified dashboard solution built on a modern Microsoft technology stack. It does not replace legacy systems but integrates them into a new streamlined workflow.

- **Technology Stack:** Blazor WebAssembly frontend with a .NET Web API backend
- **Integration Strategy:** Implements a Middleware Adapter layer to fetch and normalize data from Oracle and PCS APIs in real time
- **Security Architecture:** Utilizes the Backend for Frontend (BFF) pattern to securely manage vendor API keys and JWT-based authentication for stateless, secure user sessions

---

## Business Value

### Operational Efficiency
Eliminates "application toggling," reducing case review time by an estimated 30–40%.

### Data Integrity
Automated syncing via webhooks ensures that when a payment is processed in the collection system, it is immediately visible to department staff.

### Scalability
The modular architecture allows new city departments or vendor integrations to be added to the dashboard with minimal refactoring, protecting the city's long-term technology investment.

---

## Conclusion

Project ODIN represents a meaningful shift toward a more integrated, data-driven municipal infrastructure. By centralizing different data streams, the City can improve service delivery to the public while maintaining high standards for data security and fiscal responsibility.
