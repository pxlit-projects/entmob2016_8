package be.pxl.spring.service;

import java.util.List;

import be.pxl.spring.domain.User;

public interface UserService {

	public abstract User save(User u);

	public abstract User findOne(int id);

	public abstract List<User> findByName(String name);

	public abstract List<User> findByDepartment(String department);

	public abstract void flush();

	public abstract void delete(User u);

}