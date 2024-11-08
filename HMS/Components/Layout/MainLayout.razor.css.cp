.page {
    position: relative;
    display: flex;
    flex-direction: row;

    font-family: 'Fraunces', serif;
}

main {
    flex: 1;
}

.sidebar {
    background-image: linear-gradient(180deg, rgb(5, 39, 103) 0%, #3a0647 70%);
}

.top-row {
    background-color: #f7f7f7;
    border-bottom: 1px solid #d6d5d5;
    justify-content: space-between;
    height: 5rem;
    display: flex;
    align-items:center;
    padding-left: 1rem;
}

.title-icon{
    width: 25px;
    height: 25px;
    background-image: url('/images/plane_logo.png');
    background-repeat:no-repeat;
}

.nav-title{
    font-size: 1.0rem;
    font-style: italic;
    font-weight: bold;
    color: #1B1F2D;
    flex-grow: 1;
    margin-right: 5px;
    margin-top: 5px;
}

.navbar-toggle {
    background-color: #f7f7f7;
    border: none;
    color: white;
    width: 3rem;
    height: 3.2rem;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin: 4px 2px;
    background-image: url('data:image/svg+xml;charset=UTF8,%3csvg xmlns%3d"http%3a//www.w3.org/2000/svg" viewBox%3d"0 0 30 30"%3e%3cpath stroke%3d"rgba(0, 0, 0, 0.5)" stroke-width%3d"2" d%3d"M4 7h22M4 15h22M4 23h22"%3e%3c/path%3e%3c/svg%3e');
    background-position: center;
    cursor: pointer;
}

.navbar-nav{
    display: flex;
    flex-direction: column;
    padding-left: 5px;
}

.nav-link {
    color: #000;
    text-decoration: none;
}

.nav-link:hover {
    color: #0056b3;
}

.navbar-collapse {
    height: auto;
    flex-basis: 0%;
}

.nav-item {
    font-size: 1.5rem;
}

@media (max-width: 640.98px) {
    .top-row {
        justify-content: space-between;
    }

    .top-row ::deep a, .top-row ::deep .btn-link {
        margin-left: 0;
    }
}

@media (min-width: 641px) {
    .page {
        flex-direction: row;
    }

    /*.sidebar {
        width: 250px;
        height: 100vh;
        position: sticky;
        top: 0;
    }*/

    .top-row {
        position: sticky;
        top: 0;
        z-index: 1;
    }

    .top-row.auth ::deep a:first-child {
        flex: 1;
        text-align: right;
        width: 0;
    }

    .top-row, article {
        padding-left: 2rem !important;
        padding-right: 1.5rem !important;
    }
}

.scrollmenu {
  width: 100%;
  overflow-y: auto;
  white-space: nowrap;
  position: fixed;
  margin-top: 5rem;
  top: 0;
  left: 0;
  background-color: #f7f7f7;
  z-index: 1000;
}

.scrollmenu a {
  display: inline-block;
  padding: 15px;
  text-decoration: none;
  color: black;
  transition: background-color 0.3s;
}

.scrollmenu a:hover {
  background-color: #cdcdcd;
}

@media (min-width: 1080px) {
    .top-row {
        background-color: red;
    }
}

#blazor-error-ui {
    background: lightyellow;
    bottom: 0;
    box-shadow: 0 -1px 2px rgba(0, 0, 0, 0.2);
    display: none;
    left: 0;
    padding: 0.6rem 1.25rem 0.7rem 1.25rem;
    position: fixed;
    width: 100%;
    z-index: 1000;
}

    #blazor-error-ui .dismiss {
        cursor: pointer;
        position: absolute;
        right: 0.75rem;
        top: 0.5rem;
    }
