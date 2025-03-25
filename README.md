# Tracker

**Tracker** is a collaborative platform designed to help users organize, track, and share their educational and recreational achievements or interests with friends and family. Users can build a comprehensive personal profile, manage various activities, and share interests in a controlled, private environment.

## Core Functionalities

### User Activities

Users can participate and document their involvement in:

- **Projects** (on-going or one-time)
- **Courses**
- **Certifications**
- **Competitions**

### Personal Collections

Users can maintain personal records of:

- Books (reading list)
- Movies (watchlist)
- Series (watchlist)
- Games (playlist)
- Music (playlists)
- Favorites (books, movies, series, games, music, colors)
- Hobbies list
- Wallpaper collection

## Specific Features and Requirements

### Profile and Visibility

- Users can manage visibility settings for their entire profile or individual activities (projects, courses, certifications, competitions).

### Schedule

- Users can set and share their schedules to inform other users about their current activities.

### File Management

- Users can upload relevant files related to projects, courses, certifications, and competitions.

### Subjects and Tags

- Activities (projects, courses, certifications, competitions) are associated with subjects that indicate the concept, technology, or topic covered.
- Subjects are globally available and shared among all users.
- Activities can also be organized and classified using tags. Tags can denote the current state or any other relevant category.
- Users maintain their own tag lists but can view and adopt tags used by others.

### Linking Activities

- Projects can be linked to relevant courses.
- Courses can be linked to relevant certifications.
- Competitions can have relevant projects.

### Project Progression

- Projects support two progression types:
  - **On-going** (continuous)
  - **One-time** (finite, with a specific endpoint)

## Technical Requirements

### User Management

- Mandatory sign-in; users must log in to access the platform.
- User registration is disabled by default and controlled by an admin.
- Two user roles:
  - **Admin**: Can manage user accounts and application settings.
  - **User**: Regular user access.

### Data Privacy and Security

- All data within the platform is completely private and secure.
- Users can individually control who has access to view their profile and specific activities through customizable visibility settings.

### Hosting and Infrastructure

- Full self-hosting capabilities.
- Multiple database engines support (PostgreSQL, MySQL, and MariaDB).

### Email and Notifications

- SMTP support for:
  - Email confirmation
  - Password recovery
  - General notifications

### Admin Configuration

Admins can configure:

- Application timezone
- SMTP server settings
- User registration (enable/disable)
