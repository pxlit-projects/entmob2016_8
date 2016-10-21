package be.pxl.spring.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.User;

@Repository
public interface UserRepository extends JpaRepository<User, Integer>{
	//LazyLoading is enabled by default, these queries will not return a list of sessions
	@Transactional(readOnly = true)
	@Query("select u from User u where (u.firstName like %?1%) or (u.lastName like %?1%)")
	List<User> findByName(String name);

	@Transactional(readOnly=true)
	List<User> findByDepartment(String department);

	@Transactional(readOnly=true)
	@Query("select u from User u LEFT JOIN FETCH u.sessions s where u.id = ?1 ")
	User findById(int id);
}
